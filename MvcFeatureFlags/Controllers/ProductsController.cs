using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using MvcFeatureFlags.Context;
using MvcFeatureFlags.Models;

namespace MvcFeatureFlags.Controllers;

public class ProductsController : Controller
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _environment;
    private readonly IFeatureManager _featureManager;

    public ProductsController(AppDbContext context,
        IWebHostEnvironment environment,
        IFeatureManager featureManager)
    {
        _context = context;
        _environment = environment;
        _featureManager = featureManager;
    }

    public async Task<IActionResult> Index()
    {
        //var products = await _context.Products.ToListAsync();
        //return View(products);
        List<Product> products = new();
        if (await _featureManager.IsEnabledAsync(FeatureFlags.ListProduct))
        {
            if (_context.Products != null)
            {
                products = await _context.Products.ToListAsync();
            }
        }

        return View(products);
    }

    [HttpGet]
    public IActionResult ExportXLS()
    {
        return View();
    }

    [HttpGet]
    public IActionResult SaleOff()
    {
        return View();
    }

    [HttpGet]
    [FeatureGate(nameof(FeatureFlags.CreateProduct))]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        if (ModelState.IsValid)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var product = await _context.Products.FindAsync(id);

        if (product == null) return NotFound();

        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (product == null) return NotFound();
        var wwwroot = _environment.WebRootPath;
        var image = Path.Combine(wwwroot, "images\\" + product.Image);
        var exists = System.IO.File.Exists(image);
        ViewBag.ImageExist = exists;

        return View(product);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null) return NotFound();

        return View(product);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        _context.Remove(id);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
