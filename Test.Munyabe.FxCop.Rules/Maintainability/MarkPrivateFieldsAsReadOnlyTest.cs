﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Munyabe.FxCop.Maintainability;

namespace Test.Munyabe.FxCop.Rules.Maintainability
{
    /// <summary>
    /// <see cref="MarkPrivateFieldsAsReadOnly"/>のルールをテストするクラスです。
    /// </summary>
    [TestClass]
    public class MarkPrivateFieldsAsReadOnlyTest : CheckTypeRuleTestBase<MarkPrivateFieldsAsReadOnly>
    {
        [TestMethod]
        public void ReadonlyFieldTest()
        {
            AssertIsSatisfied(typeof(ReadonlyField));
        }

        [TestMethod]
        public void SetFieldTest()
        {
            AssertIsSatisfied(typeof(SetField));
        }

        [TestMethod]
        public void StaticFieldTest()
        {
            AssertIsSatisfied(typeof(StaticField));
        }

        [TestMethod]
        public void ConstMemberTest()
        {
            AssertIsSatisfied(typeof(ConstMember));
        }

        [TestMethod]
        public void PublicPropertyTest()
        {
            AssertIsSatisfied(typeof(PublicProperty));
        }

        [TestMethod]
        public void PrivateSetPropertyTest()
        {
            AssertIsSatisfied(typeof(PrivateSetProperty));
        }

        [TestMethod]
        public void GenericClassTest()
        {
            AssertIsSatisfied(typeof(GenericClass<string>));
        }

        [TestMethod]
        public void AbstractClassTest()
        {
            AssertIsSatisfied(typeof(AbstractClass));
        }

        [TestMethod]
        public void ParcialClassTest()
        {
            AssertIsSatisfied(typeof(ParcialClass));
        }

        [TestMethod]
        public void CanNotMarkReadonlyFieldTest()
        {
            AssertIsSatisfied(typeof(CanNotMarkReadonlyField));
        }

        [TestMethod]
        public void IncrementOperatorTest()
        {
            AssertIsSatisfied(typeof(IncrementOperator));
        }

        [TestMethod]
        public void TernaryExpressionTest()
        {
            AssertIsSatisfied(typeof(TernaryExpression));
        }

        [TestMethod]
        public void NullTernaryExpressionTest()
        {
            AssertIsSatisfied(typeof(NullTernaryExpression));
        }

        [TestMethod]
        public void ObjectInitializerTest()
        {
            AssertIsSatisfied(typeof(ObjectInitializer));
        }

        [TestMethod]
        public void RefParamMethodTest()
        {
            AssertIsSatisfied(typeof(RefParamMethod));
        }

        [TestMethod]
        public void RefParamNotVoidMethodTest()
        {
            AssertIsSatisfied(typeof(RefParamNotVoidMethod));
        }

        [TestMethod]
        public void EventTest()
        {
            AssertIsSatisfied(typeof(Event));
        }

        [TestMethod]
        public void LambdaCacheTest()
        {
            AssertIsSatisfied(typeof(LambdaCache));
        }

        [TestMethod]
        public void SetByLambdaTest()
        {
            AssertIsSatisfied(typeof(SetByLambda));
        }

        [TestMethod]
        public void DelegateClosureTest()
        {
            AssertIsSatisfied(typeof(DelegateClosure));
        }

        [TestMethod]
        public void LambdaClosureTest()
        {
            AssertIsSatisfied(typeof(LambdaClosure));
        }

        [TestMethod]
        public void SetAndYieldReturnTest()
        {
            AssertIsSatisfied(typeof(SetAndYieldReturn));
        }

        [TestMethod]
        public void InitializedFieldTest()
        {
            AssertIsViolated(typeof(InitializedField));
        }

        [TestMethod]
        public void ConstructorInitializedFieldTest()
        {
            AssertIsViolated(typeof(ConstructorInitializedField));
        }

        [TestMethod]
        public void NotSetFieldTest()
        {
            AssertIsViolated(typeof(NotSetField));
        }

        [TestMethod]
        public void NotSetStaticFieldTest()
        {
            AssertIsViolated(typeof(NotSetStaticField));
        }

        [TestMethod]
        public void NotSetGenericClassTest()
        {
            AssertIsViolated(typeof(NotSetGenericClass<string>));
        }

        [TestMethod]
        public void DelegateFieldTest()
        {
            AssertIsViolated(typeof(DelegateField));
        }

        [TestMethod]
        public void GetByLambdaTest()
        {
            AssertIsViolated(typeof(GetByLambda));
        }

        [TestMethod]
        public void ConstructorTernaryExpressionTest()
        {
            AssertIsNotDetectable(typeof(ConstructorTernaryExpression));
        }

        [TestMethod]
        public void YieldReturnTest()
        {
            AssertIsViolated(typeof(YieldReturn));
        }

        public class ReadonlyField
        {
            private readonly string _field = "OK";

            public string GetValue()
            {
                return _field;
            }
        }

        public class SetField
        {
            private string _field;

            public void SetValue(string value)
            {
                _field = value;
            }
        }

        public class StaticField
        {
            private static string _field;

            public static void SetValue(string value)
            {
                _field = value;
            }
        }

        public class ConstMember
        {
            private const string CONST = "OK";
        }

        public class PublicProperty
        {
            public string Property { get; set; }
        }

        public class PrivateSetProperty
        {
            public string Property { get; private set; }

            public PrivateSetProperty()
            {
                Property = "OK";
            }
        }

        public class GenericClass<T>
        {
            private string _field;

            public void SetValue(string value)
            {
                _field = value;
            }
        }

        public abstract class AbstractClass
        {
            private string _field;

            public void SetValue(string value)
            {
                _field = value;
            }
        }

        public partial class ParcialClass
        {
            private string _field;
        }

        partial class ParcialClass
        {
            public void SetValue(string value)
            {
                _field = value;
            }
        }

        public class CanNotMarkReadonlyField
        {
            private string _field;

            public CanNotMarkReadonlyField()
            {
                Initialized();
            }

            public void Initialized()
            {
                _field = "OK";
            }
        }

        public class IncrementOperator
        {
            private int _field;

            public void SetValue(string value)
            {
                _field++;
            }
        }

        public class TernaryExpression
        {
            private string _field;

            public string GetValue()
            {
                return string.IsNullOrEmpty(_field) ? "Empty" : (_field = string.Empty);
            }
        }

        public class NullTernaryExpression
        {
            private string _field;

            public string GetValue()
            {
                return _field ?? (_field = string.Empty);
            }
        }

        public class ObjectInitializer
        {
            private string _field;

            public ObjectInitializer CreateInstance()
            {
                return new ObjectInitializer { _field = "OK" };
            }
        }

        public class RefParamMethod
        {
            private string _field;

            public void Initialize()
            {
                SetField(ref _field, "OK");
            }

            private static void SetField(ref string field, string value)
            {
                field = value;
            }
        }

        public class RefParamNotVoidMethod
        {
            private string _field;

            public string Initialize()
            {
                return SetField(ref _field, "OK");
            }

            private static string SetField(ref string field, string value)
            {
                field = value;
                return value;
            }
        }

        public class Event
        {
            public delegate void CustomEventHandler();

            public event EventHandler Testing;
            public event EventHandler<EventArgs> GenericTesting;
            public event CustomEventHandler CustomEvent;
        }

        public class LambdaCache
        {
            public int[] GetEvenValues(int max)
            {
                return Enumerable.Range(0, max).Where(num => num % 2 == 0).ToArray();
            }
        }

        public class SetByLambda
        {
            private string _field;

            public void SetValue(string value)
            {
                new List<string> { value }.ForEach(each => _field = each);
            }
        }

        public class DelegateClosure
        {
            private string _field;

            public event EventHandler Testing;

            public DelegateClosure()
            {
                EventHandler handler = null;
                handler = (sender, e) =>
                {
                    Testing -= handler;
                    _field = "OK";
                };
                Testing += handler;
            }
        }

        public class LambdaClosure
        {
            private string _field;

            public void SetValue(string value)
            {
                new List<int> { 0 }.ForEach(each => _field = value);
            }
        }

        public class SetAndYieldReturn
        {
            private string _field;

            public IEnumerable<string> GetValues()
            {
                yield return _field = string.Empty;
            }
        }

        public class InitializedField
        {
            private string _field = "NG";

            public string GetValue()
            {
                return _field;
            }
        }

        public class ConstructorInitializedField
        {
            private string _field;

            public ConstructorInitializedField()
            {
                _field = "NG";
            }

            public string GetValue()
            {
                return _field;
            }
        }

        public class NotSetField
        {
            private List<string> _field = new List<string>();

            public void AddValue(string value)
            {
                _field.Add(value);
            }
        }

        public class NotSetStaticField
        {
            private static string _field;

            public static string GetValue()
            {
                return _field;
            }
        }

        public class NotSetGenericClass<T>
        {
            private string _field = "NG";

            public string GetValue()
            {
                return _field;
            }
        }

        public class DelegateField
        {
            private Delegate _delegate;
        }

        public class GetByLambda
        {
            private string _field;

            public void SetValue(List<string> values)
            {
                values.ForEach(value => value = _field);
            }
        }

        public class YieldReturn
        {
            private string _field;

            public IEnumerable<string> GetValues()
            {
                yield return _field;
            }
        }

        public class ConstructorTernaryExpression
        {
            private string _field;

            public ConstructorTernaryExpression()
            {
                var temp = string.IsNullOrEmpty(_field) ? "Empty" : (_field = string.Empty);
            }
        }
    }
}
