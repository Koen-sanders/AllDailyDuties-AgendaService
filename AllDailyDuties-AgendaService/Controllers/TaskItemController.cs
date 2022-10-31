﻿using AllDailyDuties_AgendaService.Models.Tasks;
using AllDailyDuties_AgendaService.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AllDailyDuties_AgendaService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskItemController : ControllerBase
    {
        private readonly ILogger<TaskItemController> _logger;
        private ITaskService _taskService;
        private IMapper _mapper;
        public TaskItemController(ILogger<TaskItemController> logger, ITaskService userService,
        IMapper mapper)
        {
            _logger = logger;
            _taskService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _taskService.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Create(CreateRequest model)
        {
            _taskService.Create(model);
            return Ok(new { message = "Task created" });
        }
    }
}