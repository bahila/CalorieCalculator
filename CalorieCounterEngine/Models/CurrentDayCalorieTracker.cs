﻿using System;
using System.Collections.Generic;
using CalorieCounter.Contracts;
using CalorieCounter.Models.Contracts;

namespace CalorieCounter.Models
{
    public class CurrentDayCalorieTracker : ICurrentDayCalorieTracker
    {
        public int Water { get; private set; }

        public ICollection<IProduct> ProductsConsumed { get; private set; } = new List<IProduct>();

        public ICollection<IActivity> ActivitiesPerformed { get; private set; } = new List<IActivity>();

        public void AddWater(int water)
        {
            if (water < 0)
            {
                throw new ArgumentException("Water can not be a negative number!");
            }

            //Guard.WhenArgument(water, "Water can not be a negative number!").IsLessThan(0).Throw();
            this.Water += water;
        }

        public void RemoveWater(int water)
        {
            if (water < 0)
            {
                throw new ArgumentException("Water can not be a negative number!");
            }

            //Guard.WhenArgument(water, "Water can not be a negative number!").IsLessThan(0).Throw();
            this.Water -= water;
        }

        public void AddProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentException("Product can not be null!");
            }

            //Guard.WhenArgument(product, "Product can not be null!").IsNull().Throw();
            this.ProductsConsumed.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentException("Product can not be null!");
            }

            if (this.ProductsConsumed == null)
            {
                throw new ArgumentException("The list of products is empty!");
            }
            //Guard.WhenArgument(product, "Product can not be null!").IsNull().Throw();
            //Guard.WhenArgument(this.ProductsConsumed, "The list of products is empty!").IsNull().Throw();

            this.ProductsConsumed.Remove(product);
        }

        public void AddActivity(IActivity activity)
        {
            if (activity == null)
            {
                throw new ArgumentException("Activity can not be null!");
            }

            //Guard.WhenArgument(activity, "Activity can not be null!").IsNull().Throw();
            this.ActivitiesPerformed.Add(activity);
        }

        public void RemoveActivity(IActivity activity)
        {
            if (activity == null)
            {
                throw new ArgumentException("Activity can not be null!");
            }

            if (this.ActivitiesPerformed == null)
            {
                throw new ArgumentException("The list of activities is empty!");
            }
            //Guard.WhenArgument(activity, "Activity can not be null!").IsNull().Throw();
            //Guard.WhenArgument(this.ActivitiesPerformed, "The list of activities is empty!").IsNull().Throw();

            this.ActivitiesPerformed.Remove(activity);
        }

        //    private double restingEnergy;
        //    private double suggestedDailyCalorieIntake;
        //    private int burnedCaloriesFromExercise;

        //    public CurrentDayCalorieTracker(double restingEnergy, double suggestedDailyCalorieIntake, int burnedCaloriesFromExercise = 0)
        //    {
        //        this.RestingEnergy = restingEnergy;
        //        this.SuggestedDailyCalorieIntake = suggestedDailyCalorieIntake;
        //        this.burnedCaloriesFromExercise = burnedCaloriesFromExercise;
        //    }

        //    public double RestingEnergy
        //    {
        //        get
        //        {
        //            return this.restingEnergy;
        //        }
        //        private set
        //        {
        //            Guard.WhenArgument(value, "Resting energy can not be a negative number!").IsLessThan(0).Throw();
        //            this.restingEnergy = value;
        //        }
        //    }

        //    public double SuggestedDailyCalorieIntake
        //    {
        //        get
        //        {
        //            return this.suggestedDailyCalorieIntake;
        //        }
        //        private set
        //        {
        //            Guard.WhenArgument(value, "Suggested daily calorie intake can not be a negative number!").IsLessThan(0).Throw();
        //            this.suggestedDailyCalorieIntake = value;
        //        }
        //    }

        //    public int BurnedCaloriesFromExercise
        //    {
        //        get
        //        {
        //            return this.burnedCaloriesFromExercise;
        //        }
        //        private set
        //        {
        //            Guard.WhenArgument(value, "Burned calories from exercise can not be a negative number!").IsLessThan(0).Throw();
        //            this.burnedCaloriesFromExercise = value;
        //        }
        //    }

        //    public ICollection<IProduct> Products => new List<IProduct>();

        //    public ICollection<IMeal> Meals => new List<IMeal>();

        //    public string Name => DateTime.Today.ToShortDateString();

        //    public int Calories { get; private set; }

        //    public int Protein { get; private set; }

        //    public int Carbs { get; private set; }

        //    public int Fat { get; private set; }

        //    public int Sugar { get; private set; }

        //    public int Fiber { get; private set; }

        //    public double CalculateDailyIntake()
        //    {
        //        foreach (var product in this.Products)
        //        {
        //            this.Calories += product.Calories;
        //            this.Protein += product.Protein;
        //            this.Carbs += product.Carbs;
        //            this.Fat += product.Fat;
        //            this.Sugar += product.Sugar;
        //            this.Fiber += product.Fiber;
        //        }

        //        foreach (var meal in this.Meals)
        //        {
        //            foreach (var product in meal.Products)
        //            {
        //                this.Calories += product.Calories;
        //                this.Protein += product.Protein;
        //                this.Carbs += product.Carbs;
        //                this.Fat += product.Fat;
        //                this.Sugar += product.Sugar;
        //                this.Fiber += product.Fiber;
        //            }
        //        }

        //        return (this.SuggestedDailyCalorieIntake + this.BurnedCaloriesFromExercise) - this.Calories;
        //    }
    }
}