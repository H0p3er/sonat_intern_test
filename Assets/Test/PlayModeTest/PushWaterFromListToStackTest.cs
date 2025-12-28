using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace Test
{
    public class PushWaterFromListToStackTest
    {

        [UnityTest]
        public IEnumerator PushWaterFromListToStackTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.

            var gameObject = new GameObject();

            Bottle bottle = gameObject.AddComponent<Bottle>();

            gameObject.AddComponent<BottleView>();

            gameObject.AddComponent<BottleDebugger>();



            List<Water> waterList = new()
            {
                new Water(Water.WaterColor.Red),
                new Water(Water.WaterColor.Red),
                new Water(Water.WaterColor.Blue),
                new Water(Water.WaterColor.Green),
            };


            bottle.SetWaterStackFromList(waterList);

            List<Water> waterListFromStack = bottle.WaterStack.ToList();

            for (int i = 0; i < waterListFromStack.Count; i++)
            {
                Assert.That(waterList[i] == waterListFromStack[i]);
            }


            yield return null;
        }
    }

}
