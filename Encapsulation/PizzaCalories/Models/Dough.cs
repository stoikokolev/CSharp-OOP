using System;
using PizzaCalories.Common;

public class Dough
{
    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public double DoughCalories() => (2 * this.Weight) * FlourModifier() * BakingTechniqueModifier();

    private string FlourType
    {
        get => this.flourType;
        set
        {
            if (value != "white" && value != "wholegrain")
            {
                throw new Exception(GlobalConstants.InvalidTypeOfDoughMessage);
            }

            this.flourType = value;

        }
    }

    private string BakingTechnique
    {
        get => this.bakingTechnique;
        set
        {
            if (value != "crispy" && value != "chewy" && value != "homemade")
            {
                throw new Exception(GlobalConstants.InvalidTypeOfDoughMessage);
            }

            this.bakingTechnique = value;
        }
    }

    private double Weight
    {
        get => this.weight;
        set
        {
            if (value < 1 || value > 200)
            {
                throw new Exception(GlobalConstants.InvalidDoughtWeightMessage);
            }

            this.weight = value;
        }
    }

    private double BakingTechniqueModifier() => this.FlourType == "white" ? 1.5 : 1.0;

    private double FlourModifier() =>
        this.BakingTechnique switch
        {
            "crispy" => 0.9,
            "chewy" => 1.1,
            _ => 1.0
        };
}