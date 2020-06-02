﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using Ray.Infrastructure.Extensions.Json;

namespace Ray.EssayNotes.AsyncAndThread.Test
{
    [Description("线程的优先级")]
    public class Test13 : ITest
    {
        public void Run()
        {
            var thread = new Thread(PrintA)
            {
                Priority = ThreadPriority.Highest
            };
            thread.Start();

            PrintB();
        }

        private void PrintA()
        {
            Console.WriteLine($"PrintA:{Thread.CurrentThread.Priority}");

            for (int i = 0; i < 1000; i++)
            {
                Console.Write("A");
            }
        }

        private void PrintB()
        {
            Console.WriteLine($"PrintB优先级：{Thread.CurrentThread.Priority}");

            for (int i = 0; i < 1000; i++)
            {
                Console.Write("B");
            }
        }

        /*
         * 提升一个线程的优先级需要慎重，因为其他线程的执行时间就可能减少而处于（饥饿）状态。
         * 如果是希望一个线程比【其他进程】中的线程有更高的优先级，那么还必须使用System.Diagnostics命名空间下的Process类来提高进程本身的优先级
         */
    }
}
