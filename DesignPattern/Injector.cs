using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
	// not singleton
	class Injector
	{
		private static readonly IDictionary<Type, Func<object>> _providers = new Dictionary<Type, Func<object>>();

		public void Bind<Tkey, TConcrete>() where TConcrete : Tkey
		{
			_providers[typeof(Tkey)] = () => Resolve(typeof(TConcrete));
		}

		public void BindType(Type key, Type concrete)
		{
			_providers[key] = () => Resolve(concrete);
		}

		public void Bind<Tkey, T>(T instance)
		{
			_providers[typeof(Tkey)] = () => instance;
		}

		public Tkey Resolve<Tkey>()
		{
			return (Tkey) Resolve(typeof(Tkey));
		}

		public object Resolve(Type type)
		{
			Func<object> obj;
			if (_providers.TryGetValue(type, out obj))
			{
				return obj();
			}

			//if (type.IsGenericType && _providers.ContainsKey(type.GetGenericTypeDefinition()))
			//{
			//	var genericType = type.GetGenericTypeDefinition();
			//	var closedGenericType = _providers[genericType].GetType().MakeGenericType(type.GenericTypeArguments);
			//	ResolveByType(closedGenericType);
			//}

			return ResolveByType(type);
		}

		public object ResolveByType(Type type)
		{
			var ctor = type.GetConstructors().OrderByDescending(c => c.GetParameters().Length).First();
			var parameters = ctor.GetParameters().Select(p => Resolve(p.ParameterType)).ToArray();
			return ctor.Invoke(parameters);
		}
	}


	//singleton
	class Injector2
	{
		private static readonly IDictionary<Type, object> _providers = new Dictionary<Type, object>();

		public void Bind<Tkey, TConcrete>() where TConcrete : Tkey
		{
			_providers[typeof(Tkey)] = Resolve(typeof(TConcrete));
		}

		public void BindType(Type key, Type concrete)
		{
			_providers[key] = Resolve(concrete);
		}

		public void Bind<Tkey, T>(T instance)
		{
			_providers[typeof(Tkey)] = instance;
		}

		public Tkey Resolve<Tkey>()
		{
			return (Tkey)Resolve(typeof(Tkey));
		}

		public object Resolve(Type type)
		{
			object obj;
			if (_providers.TryGetValue(type, out obj))
			{
				return obj;
			}

			return ResolveByType(type);
		}

		public object ResolveByType(Type type)
		{
			var ctor = type.GetConstructors().Single();
			var parameters = ctor.GetParameters().Select(p => Resolve(p.ParameterType)).ToArray();
			return ctor.Invoke(parameters);
		}
	}
}
