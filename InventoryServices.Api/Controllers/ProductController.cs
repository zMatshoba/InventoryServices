using InventoryServices.Application.Dtos.ProductDtos;
using InventoryServices.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ViewProductDto>>> Get(CancellationToken cancellationToken)
        {
            var products = await productService.GetProductsAsync(cancellationToken);

            return Ok(products);
        }

        [HttpGet("{sku}")]
        public async Task<ActionResult<ViewProductDto>> Get(string sku, CancellationToken cancellationToken)
        {
            var product = await productService.GetProductAsync(sku, cancellationToken);

            if (product.Id == 0)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ViewProductDto>> Post(CreateProductRequest productRequest, CancellationToken cancellationToken)
        {
            var checker = await productService.GetProductAsync(productRequest.Sku, cancellationToken);

            if (checker.Id != 0)
                return BadRequest($"SKU {productRequest.Sku} already exist, please use a unique sku for every product");

            var newProduct = await productService.CreateAsync(productRequest, cancellationToken);

            if (newProduct.Id == 0)
                return UnprocessableEntity();

            return CreatedAtAction(nameof(Get), productRequest.Sku, newProduct);
        }

        [HttpPut("{sku}/update-product")]
        public async Task<ActionResult> Put(string sku,UpdateProductRequest productRequest)
        {
            if (sku != productRequest.Sku)
                BadRequest();

            var updateProduct = await productService.UpdateProductAsync(productRequest);

            if(!updateProduct)
                return BadRequest();

            return NoContent();
        }

        [HttpPut("{sku}/stock-adjustments")]
        public async Task<ActionResult> Put(string sku,int stockQty,CancellationToken cancellationToken)
        {
            var product = await productService.GetProductAsync(sku, cancellationToken);

            if(product.Id == 0)
                return NotFound();

            var result = await productService.StockAdjustmentAsync(sku, stockQty, cancellationToken);

            if(!result)
                return BadRequest();

            return NoContent();
        }
    }
}
