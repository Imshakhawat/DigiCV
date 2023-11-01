using Autofac;
using Crud.Persistance.Features.Membership;
using CVBuilder.Domain.Entities;
using CVBuilder.Web.Areas.Users.Models;
using CVBuilder.Web.Models;
using CVBuilder.Web.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace CVBuilder.Web.Areas.Users.Controllers
{
    [Area("Users")]
    public class CoverLetterController : Controller
    {
        private readonly IHostingEnvironment _environment;
        ILifetimeScope _scope;

        private readonly UserManager<ApplicationUser> _userManager;

        public CoverLetterController(IHostingEnvironment hostingEnvironment, ILifetimeScope scope,
            UserManager<ApplicationUser> userManager)
        {
            _environment = hostingEnvironment;
            _scope = scope;
            _userManager = userManager;

        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);


            var model = _scope.Resolve<CoverLetterDataModel>();
            model.Load(new Guid(userId));
            return View(model);

        }




        public IActionResult Create()
        {
            var model = _scope.Resolve<CoverLetterCreateModel>();

            return View(model);
        }
       
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CoverLetterCreateModel model)
        {

            model.ResolveDependency(_scope);

            if (ModelState.IsValid)
            {
                try
                {


                    var userId = _userManager.GetUserId(HttpContext.User);

                    //var cvtemplate = await _resumeFactory.PrepareResume(CVData);
                    CommonClass.Uid = userId;
                    model.CreateCoverLetter();
                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = "Successfully added a new Cover Letter.",
                        Type = ResponseTypes.Success
                    });
                    return RedirectToAction("Index");
                }
                catch (DuplicateNameException ex)
                {

                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = ex.Message,
                        Type = ResponseTypes.Danger
                    });
                }
                catch (Exception e)
                {


                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = "There was a problem in creating Cover Letter.",
                        Type = ResponseTypes.Danger
                    });
                }
            }

            return View(model);
        }


        //delete
        public async Task<JsonResult> CoverLetterDelete(int id, Guid userId)
        {

            //var model = 
            var model = _scope.Resolve<CoverLetterDeleteModel>();
            model.ResolveDependency(_scope);
            model.DeleteCoverLetter(id, userId);
            return new JsonResult("Delete Successful");
        }

        //update
        public async Task<JsonResult> CoverLetterUpdate(UserCoverLetter userCoverLetter)
        {

            //var model = 
            var model = _scope.Resolve<CoverLetterUpdateModel>();
            model.ResolveDependency(_scope);
            model.UserCoverLetter = userCoverLetter;
            model.UpdateCoverLetter();
            return new JsonResult("Update Successful");

        }
    }
}
