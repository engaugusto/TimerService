using System;
using NUnit.Framework;

namespace TimerService.Test
{
    [TestFixture]
    public class TimerServiceTest
    {
        bool ret = false;
        void funcRetorno()
        {
            ret = true;
            return;
        }
        
        [Test]
        public void TestTimer(){
            TimerTick t = new TimerTick();
            t.StartTimer();
            TimerService.TimerTick.TimerTicked tick = new TimerTick.TimerTicked(funcRetorno);
            t.Ticked = tick; 
            
            while(ret==false){
            }

            Assert.AreEqual(ret, true);
        }
    }
}
