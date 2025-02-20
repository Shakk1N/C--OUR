using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ExpenseController : Controller
{
    private readonly ExpenseContext _context;

    public ExpenseController(ExpenseContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Expenses.Include(e => e.Category).ToListAsync());
    }

    public IActionResult Create()
    {
        ViewBag.Categories = _context.Categories.ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Expense expense)
    {
        if (ModelState.IsValid)
        {
            _context.Add(expense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Categories = _context.Categories.ToList();
        return View(expense);
    }
}