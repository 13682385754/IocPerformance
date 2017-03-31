﻿using System;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using Rezolver;
using Rezolver.Targets;

namespace IocPerformance.Adapters
{
    public sealed class RezolverContainerAdapter : ContainerAdapterBase
    {
        private Container container;

        public override string PackageName => "Rezolver";

        public override string Url => "http://rezolver.co.uk";

        public override bool SupportGeneric => true;

        public override bool SupportsBasic => true;

        public override bool SupportsChildContainer => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportAspNetCore => true;

        public override object Resolve(Type type) => this.container.Resolve(type);

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            this.container = null;
        }

        public override void Prepare()
        {
            var targets = new TargetContainer();
            RegisterBasic(targets);
            RegisterPropertyInjection(targets);
            RegisterOpenGeneric(targets);
            RegisterMultiple(targets);
            targets.Populate(CreateServiceCollection());

            this.container = new Container(targets);
        }

        public override void PrepareBasic()
        {
            var targets = new TargetContainer();
            RegisterBasic(targets);
            this.container = new Container(targets);
        }

        private static void RegisterBasic(ITargetContainer targets)
        {
            RegisterDummies(targets);
            RegisterStandard(targets);
            RegisterComplexObject(targets);
        }

        private static void RegisterDummies(ITargetContainer targets)
        {
            targets.RegisterType<DummyOne, IDummyOne>();
            targets.RegisterType<DummyTwo, IDummyTwo>();
            targets.RegisterType<DummyThree, IDummyThree>();
            targets.RegisterType<DummyFour, IDummyFour>();
            targets.RegisterType<DummyFive, IDummyFive>();
            targets.RegisterType<DummySix, IDummySix>();
            targets.RegisterType<DummySeven, IDummySeven>();
            targets.RegisterType<DummyEight, IDummyEight>();
            targets.RegisterType<DummyNine, IDummyNine>();
            targets.RegisterType<DummyTen, IDummyTen>();
        }

        private static void RegisterStandard(ITargetContainer targets)
        {
            // two options for singletons in Rezolver - a singleton target wrapping
            // another, and a straight constant object.  I think for the purposes of the
            // test we should be wrapping a constructor target.
            targets.RegisterSingleton<Singleton1, ISingleton1>();
            targets.RegisterSingleton<Singleton2, ISingleton2>();
            targets.RegisterSingleton<Singleton3, ISingleton3>();
            targets.RegisterType<Transient1, ITransient1>();
            targets.RegisterType<Transient2, ITransient2>();
            targets.RegisterType<Transient3, ITransient3>();
            targets.RegisterType<Combined1, ICombined1>();
            targets.RegisterType<Combined2, ICombined2>();
            targets.RegisterType<Combined3, ICombined3>();
        }

        private static void RegisterComplexObject(ITargetContainer targets)
        {
            targets.Register(new SingletonTarget(ConstructorTarget.Auto<FirstService>()), typeof(IFirstService));
            targets.Register(new SingletonTarget(ConstructorTarget.Auto<SecondService>()), typeof(ISecondService));
            targets.Register(new SingletonTarget(ConstructorTarget.Auto<ThirdService>()), typeof(IThirdService));
            targets.Register(ConstructorTarget.Auto<SubObjectOne>(), typeof(ISubObjectOne));
            targets.Register(ConstructorTarget.Auto<SubObjectTwo>(), typeof(ISubObjectTwo));
            targets.Register(ConstructorTarget.Auto<SubObjectThree>(), typeof(ISubObjectThree));
            targets.Register(ConstructorTarget.Auto<Complex1>(), typeof(IComplex1));
            targets.Register(ConstructorTarget.Auto<Complex2>(), typeof(IComplex2));
            targets.Register(ConstructorTarget.Auto<Complex3>(), typeof(IComplex3));
        }

        private static void RegisterPropertyInjection(ITargetContainer targets)
        {
            // this method is temporary till I add auto property injection - thinking I might do it as
            // an extension target that can be added to any other target (except another target)
            targets.Register(new SingletonTarget(ConstructorTarget.Auto<ServiceA>()), typeof(IServiceA));
            targets.Register(new SingletonTarget(ConstructorTarget.Auto<ServiceB>()), typeof(IServiceB));
            targets.Register(new SingletonTarget(ConstructorTarget.Auto<ServiceC>()), typeof(IServiceC));

            targets.Register(ConstructorTarget.Auto<SubObjectA>(DefaultMemberBindingBehaviour.Instance), typeof(ISubObjectA));
            targets.Register(ConstructorTarget.Auto<SubObjectB>(DefaultMemberBindingBehaviour.Instance), typeof(ISubObjectB));
            targets.Register(ConstructorTarget.Auto<SubObjectC>(DefaultMemberBindingBehaviour.Instance), typeof(ISubObjectC));

            targets.Register(ConstructorTarget.Auto<ComplexPropertyObject1>(DefaultMemberBindingBehaviour.Instance), typeof(IComplexPropertyObject1));
            targets.Register(ConstructorTarget.Auto<ComplexPropertyObject2>(DefaultMemberBindingBehaviour.Instance), typeof(IComplexPropertyObject2));
            targets.Register(ConstructorTarget.Auto<ComplexPropertyObject3>(DefaultMemberBindingBehaviour.Instance), typeof(IComplexPropertyObject3));
        }

        private static void RegisterOpenGeneric(ITargetContainer targets)
        {
            targets.Register(GenericConstructorTarget.Auto(typeof(GenericExport<>)), typeof(IGenericInterface<>));
            targets.Register(GenericConstructorTarget.Auto(typeof(ImportGeneric<>)), typeof(ImportGeneric<>));
        }

        private static void RegisterMultiple(ITargetContainer targets)
        {
            targets.RegisterMultiple(
                new[]
                {
                    ConstructorTarget.Auto<SimpleAdapterOne>(),
                    ConstructorTarget.Auto<SimpleAdapterTwo>(),
                    ConstructorTarget.Auto<SimpleAdapterThree>(),
                    ConstructorTarget.Auto<SimpleAdapterFour>(),
                    ConstructorTarget.Auto<SimpleAdapterFive>()
                },
            typeof(ISimpleAdapter));
            targets.Register(ConstructorTarget.Auto<ImportMultiple1>());
            targets.Register(ConstructorTarget.Auto<ImportMultiple2>());
            targets.Register(ConstructorTarget.Auto<ImportMultiple3>());
        }

        public override IChildContainerAdapter CreateChildContainerAdapter()
        {
            return new RezolverChildContainerAdapter(this.container);
        }

        public class RezolverChildContainerAdapter : IChildContainerAdapter
        {
            private readonly IContainer parent;
            private IContainer child;
            private IContainerScope childScope;

            public RezolverChildContainerAdapter(IContainer parent)
            {
                this.parent = parent;
            }

            public void Dispose()
            {
                this.childScope.Dispose();
            }

            public void Prepare()
            {
                var targets = new TargetContainer();

                targets.RegisterType<ScopedTransient, ITransient1>();
                targets.RegisterType<ScopedCombined1, ICombined1>();
                targets.RegisterType<ScopedCombined2, ICombined2>();
                targets.RegisterType<ScopedCombined3, ICombined3>();
                this.child = new OverridingContainer(this.parent, targets);
                this.childScope = this.child.CreateScope();
            }

            public object Resolve(Type resolveType)
            {
                return this.childScope.Resolve(resolveType);
            }
        }
    }
}