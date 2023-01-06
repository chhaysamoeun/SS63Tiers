using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS63Tiers.Api.Models;
using SS63Tiers.Api.Service;

namespace SS63Tiers.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employee;

    public EmployeeController(IEmployeeService employee)
    {
        _employee = employee;
    }
    // GET: api/Employee
    [HttpGet]
    public async Task<IEnumerable<Employee>> Get()
        => await _employee.EmployeeList();

    // GET: api/Employee/5
    [HttpGet("{id}")]
    public async Task<Employee> Get(Guid id)
        => await _employee.EmployeeList(id);
    // GET: api/Employee/5
    [HttpGet("search/{search}")]
    public async Task<List<Employee>> Get(string search)
    {
        var data = await _employee.Search(search);
        return data;
    }

    // POST: api/Employee
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Employee employee)
    {
        if (ModelState.IsValid)
        {
            if(await _employee.Save(employee))
            {
                return Created("EmployeeCreated", employee);
            }
        }
        return BadRequest(ModelState);
    }

    // PUT: api/Employee/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] Employee employee)
    {
        if(ModelState.IsValid || id == employee.EmployeeId)
        {
            if(await _employee.Update(employee,id))
            {
                return Ok();
            }
        }
        return BadRequest(ModelState);
    }

    // DELETE: api/Employee/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        if(await _employee.Delete(id))
        {
            return Ok();
        }
        return BadRequest();
    }

}
