﻿using System;

namespace TCNAImmersiveExperiencesTest
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        ///
        /// We have a bunch of ingredients in the trunk of our taco Taco truck, and we're trying to see
        /// our expected revenue from making tacos, assuming we sell out of all tacos.
        ///
        /// Tacos sell at a fixed costs except on Tuesdays, when they're half off.
        ///
        /// A taco consists of one of each ingredient: meat, cheese, lettuce, tomato, and sauce.
        /// You can not make a taco if not all ingredients are present.
        ///
        /// We see a tip of 8-16 cents, so we like to calculate that in our total expected revenue
        /// (Don't tell accounting)
        ///
        /// You've been asked to code review what Tommy wrote below. While the code below works, what
        /// comments, suggestions, rewrites would you bring up?
        ///
        /// </summary>
        /// <param name="aoIngredientList">Each of the ingredients quantity sent in.</param>
        /// <param name="aoIngredientCosts">Each of the costs of the ingredients sent in (matches ingredient list order)</param>
        /// <returns></returns>
        TacoInformation oToyotasTacomaTacoTruckTrunkTrouble(int[] aoIngredientList, float[] aoIngredientCosts)
        {
            TacoInformation returnInfo = new TacoInformation();
            float fBaseChargePricePerTaco = 2.34f;

            bool bIsSaleHappening = false;

            int iterWIthLowestIngredient = 0;
            for(int i = 0; i < aoIngredientList.Length; ++i)
            {
                if(aoIngredientList[i] < aoIngredientList[iterWIthLowestIngredient])
                {
                    iterWIthLowestIngredient = i;
                }
            }

            while (aoIngredientList[iterWIthLowestIngredient] > 0)
            {
                for (int i = 0; i < aoIngredientList.Length; ++i)
                {
                    aoIngredientList[i]--;
                }

                if (DateTime.Now.DayOfWeek.ToString() == "Tuesday")
                {
                    bIsSaleHappening = true;
                }

                returnInfo.fTotalAvailableTacos++;

                var randomGen = new System.Random();
                returnInfo.fTotalChargeForTacos += fBaseChargePricePerTaco + randomGen.Next(8, 16);

                if(bIsSaleHappening)
                {
                    returnInfo.fTotalChargeForTacos -= fBaseChargePricePerTaco / 2;
                }

                for (int i = 0; i < aoIngredientCosts.Length; ++i)
                {
                    returnInfo.fOurTotalIngredientCosts += aoIngredientCosts[i];
                }
            }

            return returnInfo;
        }
    }

    public struct TacoInformation
    {
        public float fTotalAvailableTacos;
        public float fTotalChargeForTacos;
        public float fOurTotalIngredientCosts;
    }
    public interface main
    {
        public TacoInformation GetTacoInformation();
    }
}
