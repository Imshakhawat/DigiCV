
using Autofac;
using Crud.Persistance.Features.Membership;
using CVBuilder.Domain.CVEntites;
using CVBuilder.Domain.Entities;
using CVBuilder.Web.Areas.Admin.Models.ResumeTemplateModel;
using CVBuilder.Web.Areas.Users.Factory;
using CVBuilder.Web.Areas.Users.Models;
using CVBuilder.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Org.BouncyCastle.Ocsp;
using System.Collections;
using System.Xml.Linq;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace CVBuilder.Web.Areas.Users.Controllers
{
	[Area("Users")]
	public class ResumeController : Controller
	{
		//  [Authorize]
		private readonly IHostingEnvironment _environment;
		private readonly IResumeFactory _resumeFactory;
		private readonly ILifetimeScope _scope;
		private readonly UserManager<ApplicationUser> _userManager;
		private  Resume _resumeModel;
		private IList<ResumeTemplate>? _resumetemplates;
		
		public ResumeController(IHostingEnvironment hostingEnvironment, ILifetimeScope scope,
		   IResumeFactory resumeFactory, UserManager<ApplicationUser> userManager)
		{
			_environment = hostingEnvironment;
			_resumeFactory = resumeFactory;
			_scope = scope;
			_userManager = userManager;
           

        }
		public IActionResult ResumeBuilder()
		{
			return View();
		}

		public async Task<IActionResult> EditResumeData()
		{
			var httpCon = HttpContext.Request.QueryString;
			var queryString = QueryHelpers.ParseQuery(httpCon.Value);
			int.TryParse(queryString["tempId"].ToString(), out int tempId);

            var model = await GetResumeByUserAndTempleteId(tempId);
			_resumeModel = model;
            var cvData = model;
			if (cvData != null)
			{
				ViewBag.Project = cvData.Projects;
				ViewBag.Skills = cvData.Skills.SkillsList;
				ViewBag.References = cvData.References;
				ViewBag.ResumeName = cvData.ResumeName;
				ViewBag.Education = cvData.Education;
				ViewBag.Introduction = cvData.Introduction;
				ViewBag.ProfessionalSummary = cvData.ProfessionalSummary;
				ViewBag.ProfessionalTraining = cvData.ProfessionalTraining;
				ViewBag.WorkExperiences = cvData.WorkExperiences;

			}
			return View("edit-template");
		}

		//Need to change action name view resume/cv 
		// it take a resume id 
		// ger al resume info by id with template name or id 
		// return to view page as per template id
		public IActionResult ShowTemplateOne()
		{
			var httpCon = HttpContext.Request.QueryString;
			var queryString = QueryHelpers.ParseQuery(httpCon.Value);
			int.TryParse(queryString["tempId"].ToString(), out int tempId);

            //ViewBag.SheareLink = $"https://localhost:7231/Users/Resume/ShowTemplateOne?tempId={tempId}";
            var model = GetResumeByUserAndTempleteId(tempId);
			var cvData = model.Result;
			//List<string> cvTemplate = new List<string>();
			//cvTemplate.Add("templete-two");
			//cvTemplate.Add("template-one");
            var templates = _scope.Resolve<ResumeTemplateListModel>();
            if (cvData != null)
			{
				var resumTempltes = templates.GetResumeTemplates();
                ViewBag.Project = cvData.Projects;
				ViewBag.Skills = cvData.Skills.SkillsList;
				ViewBag.References = cvData.References;
				ViewBag.ResumeName = cvData.ResumeName;
				ViewBag.Education = cvData.Education;
				ViewBag.Introduction = cvData.Introduction;
				ViewBag.ProfessionalSummary = cvData.ProfessionalSummary;
				ViewBag.ProfessionalTraining = cvData.ProfessionalTraining;
				ViewBag.WorkExperiences = cvData.WorkExperiences;
				ViewBag.templates = resumTempltes;
                _resumetemplates = resumTempltes as IList<ResumeTemplate>;

            }

				var defaultTemplate = _resumetemplates.Where(x => x.Id == tempId).FirstOrDefault();
			
			//ChooseTemplate();
            return View(defaultTemplate.TemplateName);
		}

		public async Task<bool> DeleteResumeByTemplateId(int templateId)
		{
			try
			{
				var userId = _userManager.GetUserId(HttpContext.User);
				var model = _scope.Resolve<ResumeCreateModel>();
				var result = await model.GetCVByByUserIdWithTempateId(Guid.Parse(userId), templateId);
				model.DeleteResumeData(result);
				return true;
			}
			catch (Exception ex)
			{
				return false;

			}
		}

		[Authorize]
		public IActionResult Index()
		{
			return View();
		}

		public async Task<Resume> GetResumeByUserAndTempleteId(int tempId)
		{
			var userId = _userManager.GetUserId(HttpContext.User);
			var model = _scope.Resolve<ResumeCreateModel>();
			var result = await model.GetCVByByUserIdWithTempateId(Guid.Parse(userId), tempId);
			return result;
		}
		public async Task<JsonResult> GetCVByUserIdWithTemplateId()
		{
			var param1Value = HttpContext.Request.Query.ContainsKey("tempId");
			var userId = _userManager.GetUserId(HttpContext.User);
			var model = _scope.Resolve<ResumeCreateModel>();
			model.ResolveDependency(_scope);
			//using the model according to sirs model
			var result = await model.GetCVByByUserIdWithTempateId(Guid.Parse(userId), 0); //fully function insertion resume
			return new JsonResult(result);
		}
		// update 
		public async Task<JsonResult> UpdateCVByUserIdAndTemplateId(Resume cVTemplate, ResumeDTO CVData)
		{
			var model = _scope.Resolve<ResumeUpdateModel>();
			model.ResolveDependency(_scope);
			var result = await model.CVUpdateByUserIdAndTemplateId(cVTemplate, CVData);
			return new JsonResult(result);
		}

		//Generate Resume 
		public async Task<JsonResult> CVBuilderAdd(ResumeDTO CVData)
		{
			var queryString = QueryHelpers.ParseQuery(CVData.Url);
			int tempId = 0;
			int.TryParse(queryString["tempId"].ToString(), out tempId);

			//    return
			var model = _scope.Resolve<ResumeCreateModel>();
			model.ResolveDependency(_scope);
			var userId = _userManager.GetUserId(HttpContext.User);

			var existingCVData = await model.GetCVByByUserIdWithTempateId(Guid.Parse(userId), tempId);
			if (existingCVData != null)
			{
				// update CV 
				try
				{

					return new JsonResult("CV all rady exists");
				}
				catch (Exception ex)
				{
					return null;
				}
			}

			try
			{
				var cvtemplate = await _resumeFactory.PrepareResume(CVData);
				cvtemplate.UserId = new Guid(userId);//for testing purpose
				cvtemplate.ResumeTemplteId = tempId;
				//var model = 
				model.CVTemplate = cvtemplate;//using the model according to sirs model
				model.CreateResume(); //fully function insertion resume
				return new JsonResult("Add Successful");

				
			}
			catch (Exception ex)
			{
				return new JsonResult("Some Thing Wrong");

			}
		}


		/// <summary>
		/// 	[Route("/UpdateRemuseData")]
		/// </summary>
		/// <param name="CVData"></param>
		/// <returns></returns>
		[Route("/UpdateRemuseData")]

		public async Task<JsonResult> UpdateRemuseData(ResumeDTO CVData)
		{
			var queryString = QueryHelpers.ParseQuery(CVData.Url);
			int tempId = 0;
			int.TryParse(queryString["tempId"].ToString(), out tempId);
			var model = _scope.Resolve<ResumeCreateModel>();
			model.ResolveDependency(_scope);
			var userId = _userManager.GetUserId(HttpContext.User);

			var existingCVData = await model.GetCVByByUserIdWithTempateId(Guid.Parse(userId), tempId);
			if (existingCVData != null)
			{
				var rr = model.DeleteResumeData(existingCVData);

			}
			try
			{
				var cvtemplate = await _resumeFactory.PrepareResume(CVData);
				cvtemplate.UserId = new Guid(userId);//for testing purpose
				cvtemplate.ResumeTemplteId = tempId;
				//var model = 
				model.CVTemplate = cvtemplate;//using the model according to sirs model
				model.CreateResume(); //fully function insertion resume
				return new JsonResult("Updated Successful");
			}
			catch (Exception ex)
			{
				return new JsonResult("Some Thing Wrong");

			}

		}


		public async Task<JsonResult> ImageUpload()
		{
			string base64 = Request.Form["image"];
			byte[] bytes = Convert.FromBase64String(base64.Split(',')[1]);
			string filePath = Path.Combine(this._environment.WebRootPath, "images", $"{_userManager.GetUserId(HttpContext.User)}.png");
			using (FileStream stream = new FileStream(filePath, FileMode.Create))
			{
				stream.Write(bytes, 0, bytes.Length);
				stream.Flush();
			}
			return new JsonResult($"{_userManager.GetUserId(HttpContext.User)}.png");
		}


		//public IActionResult ChooseTemplate()
		//{
		//	var model = _scope.Resolve<ResumeTemplateListModel>();
		//	ViewBag.Template = model;

		//	return View(model);
		//}


		//[HttpGet("/ChangeTemplate/temp")]
		public async Task<IActionResult> ChangeTemplate() {
            var httpCon = HttpContext.Request.QueryString;
            var queryString = QueryHelpers.ParseQuery(httpCon.Value);
            int.TryParse(queryString["tempId"].ToString(), out int tempId);
            int.TryParse(queryString["temp"].ToString(), out int temp);
            _resumetemplates = _scope.Resolve<ResumeTemplateListModel>().GetResumeTemplates();
            var userId = _userManager.GetUserId(HttpContext.User);
            var model = _scope.Resolve<ResumeCreateModel>();
            var cvData = await GetResumeByUserAndTempleteId(tempId);
            
            ViewBag.Project = cvData.Projects;
            ViewBag.Skills = cvData.Skills.SkillsList;
            ViewBag.References = cvData.References;
            ViewBag.ResumeName = cvData.ResumeName;
            ViewBag.Education = cvData.Education;
            ViewBag.Introduction = cvData.Introduction;
            ViewBag.ProfessionalSummary = cvData.ProfessionalSummary;
            ViewBag.ProfessionalTraining = cvData.ProfessionalTraining;
            ViewBag.WorkExperiences = cvData.WorkExperiences;
			var template = _resumetemplates.Where(x => x.Id == temp).FirstOrDefault();
            return View(template.TemplateName);
		}

	}
}
