﻿using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CSharp.Web.API.Models;

public class TodoContext : DbContext
{
	public TodoContext(DbContextOptions<TodoContext> options)
		: base(options)
	{
	}

	public DbSet<TodoItem> TodoItems { get; set; } = null!;
}