using System.Security.Claims;
using lab6.Repositories.Interfaces;
using lab6.Models.DTO;
using lab6.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace lab6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
                return NotFound("Project not found");

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectDTO project)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newProject = await _projectService.CreateProjectAsync(userId, project);
            return CreatedAtAction(nameof(GetProjectById), new { id = newProject.ProjectId }, newProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(Guid id, [FromBody] UpdateProjectDTO project)
        {
            var updatedProject = await _projectService.UpdateProjectAsync(id, project);
            if (updatedProject == null)
                return NotFound("Project not found");

            return Ok(updatedProject);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var success = await _projectService.DeleteProjectAsync(id);
            if (!success)
                return NotFound("Project not found");

            return NoContent();
        }
    }
}