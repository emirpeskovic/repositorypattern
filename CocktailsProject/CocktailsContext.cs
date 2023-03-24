﻿using System.Text.Json.Serialization;
using CocktailsProject.Converter;
using CocktailsProject.Entities;
using CocktailsProject.Managers;
using Microsoft.EntityFrameworkCore;

namespace CocktailsProject;

public class CocktailsContext : DbContext
{
    public CocktailsContext(DbContextOptions<CocktailsContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Drink>();
        modelBuilder.Entity<Ingredient>();
        modelBuilder.Entity<Recipe>()
            .Property(recipe => recipe.Ingredients)
            .HasColumnType("text")
            .HasConversion(new IngredientConverter());
    }
    
    public IRepository<T> GetRepository<T>() where T : class
    {
        return new Repository<T>(this);
    }
}