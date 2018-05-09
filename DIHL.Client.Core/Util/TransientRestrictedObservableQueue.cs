using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Platform.Core;

namespace DIHL.Client.Core.Util
{
	/// <summary>
	/// An observable queue that only reveals a few of the items it's held the longest,
	/// and removes items that have been displayed for the desired amount of time.
	/// Originally implemented IEnumerable T and INotifyCollectionChanged, but MvvmCross was interfering.
	/// </summary>
	/// <typeparam name="T">Generic type parameter</typeparam>
	public class TransientRestrictedObservableQueue<T> : ObservableCollection<T>
	{
		private readonly int _displayLimit;
		private readonly Queue<Entry> _waitingList;

		public TransientRestrictedObservableQueue(int displayLimit)
		{
			_displayLimit = displayLimit;

			_waitingList = new Queue<Entry>();
		}

		public void Enqueue(T item, TimeSpan lifeTime)
		{
			var entry = new Entry(item, lifeTime);
			_waitingList.Enqueue(entry);
			Update();
		}

		public new bool Remove(T item)
		{
			var success = base.Remove(item);
			Update();
			return success;
		}

		private void Update()
		{
			if (base.Count < _displayLimit && _waitingList.Count > 0)
			{
				var entry = _waitingList.Dequeue();
				MvxMainThreadDispatcher.Instance.RequestMainThreadAction(() => base.Add(entry.Data));

				// Task will never be removed otherwise...
				if (entry.LifeTime != TimeSpan.MaxValue)
				{
					Task.Factory.StartNew(async () =>
					{
						await Task.Delay(entry.LifeTime);
						MvxMainThreadDispatcher.Instance.RequestMainThreadAction(() => base.Remove(entry.Data));
						Update();
					});
				}
			}
		}

		private class Entry
		{
			public T Data { get; }
			public TimeSpan LifeTime { get; }

			public Entry(T data, TimeSpan lifeTime)
			{
				Data = data;
				LifeTime = lifeTime;
			}
		}
	}
}
