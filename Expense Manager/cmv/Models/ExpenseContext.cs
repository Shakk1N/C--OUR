using cmv.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class ExpenseContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Expense> Expenses { get; set; }

    public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options) { }
}