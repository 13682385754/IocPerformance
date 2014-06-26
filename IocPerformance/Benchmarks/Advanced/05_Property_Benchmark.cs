﻿using System;
using IocPerformance.Classes.Properties;

namespace IocPerformance.Benchmarks.Advanced
{
    public class Property_05_Benchmark : BenchmarkBase
    {
        public override BenchmarkResult Measure(Adapters.IContainerAdapter container)
        {
            if (container.SupportsPropertyInjection)
            {
                return base.Measure<IComplexPropertyObject1, IComplexPropertyObject2, IComplexPropertyObject3>(container);
            }
            else
            {
                return new BenchmarkResult(this, container);
            }
        }

        protected override void Warmup(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsPropertyInjection)
            {
                return;
            }

            var complex1 = (IComplexPropertyObject1)container.Resolve(typeof(IComplexPropertyObject1));
            var complex2 = (IComplexPropertyObject2)container.Resolve(typeof(IComplexPropertyObject2));
            var complex3 = (IComplexPropertyObject3)container.Resolve(typeof(IComplexPropertyObject3));

            if (complex1 == null || complex2 == null || complex3 == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.Name, typeof(IComplexPropertyObject1)));
            }

            complex1.Verify(container.Name);
            complex1.Verify(container.Name);
            complex1.Verify(container.Name);

            ComplexPropertyObject1.Instances = 0;
            ComplexPropertyObject2.Instances = 0;
            ComplexPropertyObject3.Instances = 0;
        }

        protected override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsPropertyInjection)
            {
                return;
            }

            if (ComplexPropertyObject1.Instances != BenchmarkBase.LoopCount
                || ComplexPropertyObject2.Instances != BenchmarkBase.LoopCount
                || ComplexPropertyObject3.Instances != BenchmarkBase.LoopCount)
            {
                throw new Exception(string.Format("ComplexPropertyObject count must be {0}", BenchmarkBase.LoopCount));
            }
        }
    }
}
