using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using TaskManagerApp.IServices;
using TaskManagerApp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TaskManagerApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _hostEnvironment;
        public TaskController(ITaskService service, IWebHostEnvironment hostEnvironment, IImageService imageService)
        {
            _taskService = service;
            _hostEnvironment = hostEnvironment;
            _imageService = imageService;
        }
        // GET: TaskController
        public async Task<ActionResult> Index()
        {
            var model = await _taskService.GetAllTasks();
            return View(model);
        }

        // GET: TaskController/Details/5
        public async Task<ActionResult> Details(int taskId)
        {
            var detailsModel = new TaskDetailsModel();
            detailsModel.Task = await GetTaskById(taskId);
            if (detailsModel.Task.ImageId != null && detailsModel.Task.ImageId > 0)
            {
                detailsModel.Image = await _imageService.GetImageById(detailsModel.Task.ImageId.Value);
            }
            return View(detailsModel);
        }

        // GET: TaskController/Create
        public async Task<ActionResult> Create()
        {

            return View();
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateNewTask([FromForm] TaskModel data)
        {
            try
            {
                await _taskService.CreateNewTask(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/Edit/5
        public async Task<ActionResult> Edit(int taskId)
        {
            var model = await GetTaskById(taskId);
            return View(model);
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateTask([FromForm] TaskModel data)
        {
            try
            {
                await _taskService.UpdateTask(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/Delete/5
        public async Task<ActionResult> Delete(int taskId)
        {
            var model = await GetTaskById(taskId);
            return View(model);
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteTask(int id)
        {
            try
            {
                await _taskService.DeleteTask(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/Edit/5
        public async Task<ActionResult> AddImage(int taskId)
        {
            TempData.Add("taskId", taskId);
            return View(new ImageModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateImage([FromForm] ImageModel data)
        {
            try
            {
                if (data.ImageFile.Length > 0)
                {
                    data = await SaveImageToRootPath(data);
                    var taskId = Convert.ToInt32(TempData["taskId"]);
                    var imageId = await _imageService.CreateNewImage(data);
                    if (imageId > 0)
                    {
                        await UpdateTaskDetails(taskId, imageId);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task UpdateTaskDetails(int taskId, int imageId)
        {
            var taskDetails = await GetTaskById(taskId);
            taskDetails.ImageId = imageId;
            taskDetails.HasImage = true;
            await _taskService.UpdateTask(taskDetails);
        }

        //Save image to wwwroot/image
        private async Task<ImageModel> SaveImageToRootPath(ImageModel data)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(data.ImageFile.FileName);
            string extension = Path.GetExtension(data.ImageFile.FileName);
            data.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Image/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await data.ImageFile.CopyToAsync(fileStream);
            }
            return data;
        }
        private async Task<TaskModel> GetTaskById(int id) => await _taskService.GetTaskById(id);
    }
}
