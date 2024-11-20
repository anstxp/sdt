using lab4.Models.DTO;
using lab4.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectRepository.GetAllAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
                return NotFound($"project not found");
        
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectDTO project)
        {
            var newProject = await _projectRepository.CreateProjectAsync(project);
            return CreatedAtAction(nameof(GetProjectById), new { id = newProject.ProjectId }, newProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(Guid id, [FromBody] UpdateProjectDTO project)
        {
            var updatedProject = await _projectRepository.UpdateProjectAsync(id, project);
            if (updatedProject == null)
                return NotFound("project not found");
        
            return Ok(updatedProject);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var success = await _projectRepository.DeleteProjectAsync(id);
            if (!success)
                return NotFound("project not found");
        
            return NoContent();
        }
    }
}