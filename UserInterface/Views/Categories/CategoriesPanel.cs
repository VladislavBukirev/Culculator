﻿using System;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace UserInterface.Views;

public class CategoriesPanel : StackPanel
{
    static ICategoriesFactory _categories;

    public CategoriesPanel(MainWindow mainWindow, ICategoriesFactory categories, Color categoryColor)
    {
        _categories = categories;
        Margin = new(20);
        Spacing = 10;
        var dir = Environment.CurrentDirectory;
        var pathToRecipes = dir.Replace("UserInterface", "Culculator\\RecipesDataBase.db")
            .Replace("\\bin\\Release\\net6.0", "");
        var pathToIngredients = dir.Replace("UserInterface", "Culculator\\IngredientsDataBase.db")
            .Replace("\\bin\\Release\\net6.0", "");
        var pathToAddedRecipes = dir.Replace("UserInterface", "Culculator\\AddedRecipesDataBase.db")
            .Replace("\\bin\\Release\\net6.0", "");
        foreach (var category in _categories.Create(pathToRecipes, pathToIngredients, pathToAddedRecipes).All)
        {
            var categoryContent = new ContentControl() { Content = category.Name };
            var categoryButton = new BaseTargetButton(330, 75, categoryContent, null, null, 25,
                VerticalAlignment.Center, HorizontalAlignment.Center,
                () => { mainWindow.Content = new DishesMenu(mainWindow, category, categoryColor); });
            categoryButton.Children.Add(new BlackBorder(330, 75, 1));
            Children.Add(categoryButton);
        }
    }
}