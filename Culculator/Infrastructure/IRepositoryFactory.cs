﻿namespace Culculator.Infrastructure;

public interface IRepositoryFactory
{
    public IRepository Create(string pathToRecipes, string pathToAddedRecipes);
}