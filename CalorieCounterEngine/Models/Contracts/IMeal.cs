﻿namespace CalorieCounterEngine.Contracts
{
    using System.Collections.Generic;

    public interface IMeal
    {
        /// <summary>
        /// Collection of all the products, contained in the meal.
        /// </summary>
        ICollection<IProduct> Products { get; }
        /// <summary>
        /// Meal can have a type - breakfast, lunch, dinner or snack.
        /// </summary>
        MealType Type { get; }
    }
}