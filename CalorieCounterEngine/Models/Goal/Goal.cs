﻿using Bytes2you.Validation;
using CalorieCounterEngine.Models.Contracts;
using System;

namespace CalorieCounterEngine.Models.Goal
{
    public class Goal : IGoal
    {
        private readonly double startingWeight;
        private readonly double goalWeight;
        private readonly double height;
        private readonly GenderType gender;
        private readonly GoalType type;

        public Goal(double startingWeight, double goalWeight, double height, GenderType gender, GoalType type)
        {
            Guard.WhenArgument(startingWeight, "Starting weight can not be a negative number!").IsLessThan(0).Throw();
            Guard.WhenArgument(goalWeight, "Goal weight can not be a negative number!").IsLessThan(0).Throw();
            Guard.WhenArgument(height, "Height can not be a negative number!").IsLessThan(0).Throw();
            if (!Enum.IsDefined(typeof(GenderType), gender))
                throw new ArgumentException("The provided gender type is not valid!");
            if (!Enum.IsDefined(typeof(GoalType), type))
                throw new ArgumentException("The provided goal type is not valid!");

            this.startingWeight = startingWeight;
            this.goalWeight = goalWeight;
            this.height = height;
            this.gender = gender;
            this.type = type;
        }

        public double StartingWeight => this.startingWeight;

        public double GoalWeight => this.goalWeight;

        public double Height => this.height;

        public GenderType Gender => this.gender;

        public GoalType Type => this.type;

        public double CalculateRestingEnergy()
        {
            if (gender == GenderType.Male)
            {
                return (11.936 * this.StartingWeight) + (586.728 * this.Height) + 191.027 + 29.279;
            }
            else
            {
                return (11.936 * this.StartingWeight) + (586.728 * this.Height) + 29.279;
            }
        }

        public double CalculateSuggestedDailyCalorieIntake()
        {

        }

        public string CalculateSuggestedMacrosRatio()
        {
            throw new NotImplementedException();
        }

        public int CalculateSuggestedWaterIntake()
        {
            throw new NotImplementedException();
        }
    }
}