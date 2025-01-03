using ApplicationLayer.DTOs;
using ApplicationLayer.Services;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace HangfireWithWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> Add(ProductDto productDto)
    {
        await _productService.AddAsync(productDto);

        var jobId = BackgroundJob.Enqueue<IEmailService>(x => x.SendWelcomeEmail("ahmed@gmail.com", productDto.Name));
         Console.WriteLine(jobId);

         jobId = BackgroundJob.Schedule<IEmailService>(x => x.SendGettingStartedEmail("ahmed@gmail.com", productDto.Name), TimeSpan.FromSeconds(20));
        Console.WriteLine(jobId);

        return CreatedAtAction(nameof(GetById), new { id = productDto.Id }, productDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, ProductDto productDto)
    {
        if (id != productDto.Id)
        {
            return BadRequest();
        }

        await _productService.UpdateAsync(productDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _productService.DeleteAsync(id);
        return NoContent();
    }
}
