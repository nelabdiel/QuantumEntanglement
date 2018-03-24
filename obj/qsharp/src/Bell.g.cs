#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("Bell", "Set (desired : Result, q1 : Qubit) : ()", new string[] { }, "/Users/Nel/Quantum/Samples/Bell/Bell.qs", 152L, 7L, 5L)]
[assembly: OperationDeclaration("Bell", "BellTest (count : Int, initial : Result) : (Int, Int, Int)", new string[] { }, "/Users/Nel/Quantum/Samples/Bell/Bell.qs", 365L, 19L, 5L)]
#line hidden
namespace Bell
{
    public class Set : Operation<(Result,Qubit), QVoid>
    {
        public Set(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.X) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected ICallable<Qubit, Result> M
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, Result>, Microsoft.Quantum.Primitive.M>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.X>();
            }
        }

        public override Func<(Result,Qubit), QVoid> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Bell.Set", OperationFunctor.Body, _args);
                var __result__ = default(QVoid);
                try
                {
                    var (desired,q1) = _args;
#line 10 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                    var current = M.Apply<Result>(q1);
#line 11 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                    if ((desired != current))
                    {
#line 13 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                        MicrosoftQuantumPrimitiveX.Apply(q1);
                    }

#line hidden
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Bell.Set", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Result desired, Qubit q1)
        {
            return __m__.Run<Set, (Result,Qubit), QVoid>((desired, q1));
        }
    }

    public class BellTest : Operation<(Int64,Result), (Int64,Int64,Int64)>
    {
        public BellTest(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.Allocate), typeof(Microsoft.Quantum.Primitive.CNOT), typeof(Microsoft.Quantum.Primitive.H), typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.Release), typeof(Bell.Set) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected Allocate Allocate
        {
            get
            {
                return this.Factory.Get<Allocate, Microsoft.Quantum.Primitive.Allocate>();
            }
        }

        protected IUnitary<(Qubit,Qubit)> MicrosoftQuantumPrimitiveCNOT
        {
            get
            {
                return this.Factory.Get<IUnitary<(Qubit,Qubit)>, Microsoft.Quantum.Primitive.CNOT>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.H>();
            }
        }

        protected ICallable<Qubit, Result> M
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, Result>, Microsoft.Quantum.Primitive.M>();
            }
        }

        protected Release Release
        {
            get
            {
                return this.Factory.Get<Release, Microsoft.Quantum.Primitive.Release>();
            }
        }

        protected ICallable<(Result,Qubit), QVoid> Set
        {
            get
            {
                return this.Factory.Get<ICallable<(Result,Qubit), QVoid>, Bell.Set>();
            }
        }

        public override Func<(Int64,Result), (Int64,Int64,Int64)> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Bell.BellTest", OperationFunctor.Body, _args);
                var __result__ = default((Int64,Int64,Int64));
                try
                {
                    var (count,initial) = _args;
#line 22 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                    var numOnes = 0L;
#line 23 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                    var agree = 0L;
#line 24 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                    var qubits = Allocate.Apply(2L);
#line 26 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                    foreach (var test in new Range(1L, count))
                    {
#line 28 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                        Set.Apply((initial, qubits[0L]));
#line 29 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                        Set.Apply((Result.Zero, qubits[1L]));
#line 31 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                        MicrosoftQuantumPrimitiveH.Apply(qubits[0L]);
#line 32 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                        MicrosoftQuantumPrimitiveCNOT.Apply((qubits[0L], qubits[1L]));
#line 33 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                        var res = M.Apply<Result>(qubits[0L]);
#line 35 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                        if ((M.Apply<Result>(qubits[1L]) == res))
                        {
#line 37 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                            agree = (agree + 1L);
                        }

                        // Count the number of ones we saw:
#line 41 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                        if ((res == Result.One))
                        {
#line 43 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                            numOnes = (numOnes + 1L);
                        }
                    }

#line 46 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                    Set.Apply((Result.Zero, qubits[0L]));
#line 47 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                    Set.Apply((Result.Zero, qubits[1L]));
#line hidden
                    Release.Apply(qubits);
#line hidden
                    __result__ = ((count - numOnes), numOnes, agree);
                    // Return numbr of times we saw |0> and the number of times we saw |1>
#line 50 "/Users/Nel/Quantum/Samples/Bell/Bell.qs"
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Bell.BellTest", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<(Int64,Int64,Int64)> Run(IOperationFactory __m__, Int64 count, Result initial)
        {
            return __m__.Run<BellTest, (Int64,Result), (Int64,Int64,Int64)>((count, initial));
        }
    }
}