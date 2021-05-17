using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace MsOrmCodeGen.Client.Data
{
	/// <summary>
	/// LifetimeManager that scopes a object to a request.
	/// If operating in a web context the cache store will be HttpContext.Current.
	/// If operating in a cliet application the cache store will be HttpRuntime.Cache.
	/// In a web context the lifetime will be a request.
	/// In a cliet application the lifetime will be the application, 
	/// so that multi-threaded object scoping is supported.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ThreadLifetimeManager<T> : IDisposable 
		where T : class, new()
	{
		private bool m_disposed;


		/// <summary>
		/// Helper member to check for HttpContext nulls
		/// </summary>
		private static IDictionary HttpContextItems
		{
			get
			{
				if (HttpContext.Current.Items != null)
					return HttpContext.Current.Items;

				throw new HttpException("HttpContext.Current.Items is null");
			}
		}

		public T GetValue()
		{
			T o = null;

			if (HttpContext.Current != null)
			{
				o = HttpContextItems[GetKey()] as T;				
			}
			else
			{
				Cache cache = HttpRuntime.Cache;
				o = cache[GetKey()] as T;
			}

			if (o != null)
				return o;

			o = new T();
			SetValue(o);
			return o;
		}

		public void RemoveValue()
		{
			if (HttpContext.Current != null)
			{
				HttpContextItems.Remove(GetKey());
			}
			else
			{
				Cache cache = HttpRuntime.Cache;
				cache.Remove(GetKey());
			}
		}

		private void SetValue(object newValue)
		{
			if (HttpContext.Current != null)
			{
				HttpContextItems[GetKey()] = newValue;
			}
			else
			{
				Cache cache = HttpRuntime.Cache;
				cache.Insert(GetKey(), newValue, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!m_disposed && disposing)
			{
				RemoveValue();
				m_disposed = true;
			}
		}

		private string GetKey()
		{
			return typeof(T).AssemblyQualifiedName;
		}

		/// <summary>
		/// Removes the given type from the request scoped cache.
		/// </summary>
		/// <param name="type">The type that should be removed.</param>
		public static void RemoveValue(Type type)
		{
			if (HttpContext.Current != null)
			{
				HttpContextItems.Remove(type.AssemblyQualifiedName);
			}
			else
			{
				Cache cache = HttpRuntime.Cache;
				cache.Remove(type.AssemblyQualifiedName);
			}
		}
	}
}