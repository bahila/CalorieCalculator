﻿using System;
using CalorieCounter.Contracts;

namespace CalorieCounter.Models
{
    public abstract class Meal : IMeal, IProduct
    {
        protected Meal(string products, MealType type, string name)
        {
            if (!Enum.IsDefined(typeof(MealType), type))
            {
                throw new ArgumentException("The provided meal type is not valid!");
            }

            this.Products = products ?? throw new ArgumentNullException("You must add some products!");
            this.Type = type;
            //Guard.WhenArgument(name, "Name cannot be null or empty").IsNullOrWhiteSpace().Throw();
            this.Name = name ?? throw new ArgumentNullException("Name cannot be null or empty");
        }

        public string Products { get; }

        public MealType Type { get; }

        public string Name { get; }
        public decimal Weight { get; set; }

        public int Calories { get; }

        public int Protein { get; }

        public int Carbs { get; }

        public int Fat { get; }

        public int Sugar { get; }

        public int Fiber { get; }

        //TODO: Remove duplication.
        public IProduct Clone()
        {
            return (IProduct) this.MemberwiseClone();
        }
    }
}