using Autofac;
using CVBuilder.Infrastructure.Exceptions;
using CVBuilder.Web.Areas.Admin.Models.ResumeTemplateModel;
using CVBuilder.Web.Models;
using CVBuilder.Web.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CVBuilder.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResumeTemplateController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        ILifetimeScope _scope;
        ILogger<ResumeTemplateController> _logger;

        public ResumeTemplateController(ILifetimeScope scope, ILogger<ResumeTemplateController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _scope = scope;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var model = _scope.Resolve<ResumeTemplateListModel>();
            return View(model);
        }

        public IActionResult AddNewTemplate()
        {
            var model = _scope.Resolve<ResumeTemplateCreateModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddNewTemplate(ResumeTemplateCreateModel model)
        {
            model.ReturnUrl ??= Url.Content("~/");
            model.ResolveDependency(_scope);
            if (ModelState.IsValid)
            {
                try
                {
                    var folder = "Images/TemplatePicture/";
                    folder += "_" + model.TemplatePicture.FileName;
                    model.TemplatePictureUrl = "/" + folder;
                    var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    model.TemplatePicture.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                   model.CreateResumeTemplate(model.TemplateName, model.TemplatePictureUrl);

                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = "Successfully added a new template",
                        Type = ResponseTypes.Success
                    });
                    return RedirectToAction("Index");
                }
                catch (DuplicateNameException ex)
                {
                    _logger.LogError(ex, ex.Message);
                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = ex.Message,
                        Type = ResponseTypes.Danger
                    });
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Server Error");
                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = "There was a problem in Adding new Template",
                        Type = ResponseTypes.Danger
                    });
                }
            }
            return View(model);

        }
        
        public IActionResult Update(int id)
        {
            var model = _scope.Resolve<ResumeTemplateUpdateModel>();
            model.Load(id);
            return View(model);
        }

        
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Update(ResumeTemplateUpdateModel model)
        {
            model.ResolveDependency(_scope);

            if (ModelState.IsValid)
            {
                try
                {
                    model.UpdateResumeTemplate();

                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = "Successfully updated course.",
                        Type = ResponseTypes.Success
                    });

                    return RedirectToAction("Index");
                }
                catch (DuplicateNameException ex)
                {
                    _logger.LogError(ex, ex.Message);

                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = ex.Message,
                        Type = ResponseTypes.Danger
                    });
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Server Error");

                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = "There was a problem in updating course.",
                        Type = ResponseTypes.Danger
                    });
                }
            }

            return View(model);
        }


        
        public IActionResult Delete(int id)
        {
            var model = _scope.Resolve<ResumeTemplateListModel>();

            if (ModelState.IsValid)
            {
                try
                {
                    model.DeleteTemplate(id);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Server Error");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
