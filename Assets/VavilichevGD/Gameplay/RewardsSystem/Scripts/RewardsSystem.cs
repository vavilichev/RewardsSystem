using System;
using System.Collections.Generic;

namespace VavilichevGD.Gameplay.Rewards {
	public sealed class RewardsSystem {

		#region EVENTS

		public delegate void RewardsSystemHandler(object sender, Reward reward);
		public event RewardsSystemHandler OnRewardReceivedEvent; 

		#endregion

		private Dictionary<Type, IRewardHandler> rewardHandlersMap;

		public void ApplyReward(object sender, Reward reward) {
			var rewardHandler = this.GetRewardHandler(reward.info);
			rewardHandler.ApplyReward(sender, reward);
			
			this.OnRewardReceivedEvent?.Invoke(sender, reward);
		}

		private IRewardHandler GetRewardHandler(RewardInfo info) {

			IRewardHandler handler;
			
			if (this.rewardHandlersMap == null) {
				this.rewardHandlersMap = new Dictionary<Type, IRewardHandler>();
				handler = this.CreateHandler(info);
				return handler;
			}

			var requiredType = info.GetRewardHandlerType();
			if (this.rewardHandlersMap.TryGetValue(requiredType, out var foundHandler))
				return foundHandler;
			
			var createdHandler = this.CreateHandler(info);
			return createdHandler;
		}

		private IRewardHandler CreateHandler(RewardInfo info) {
			var rewardHandler = info.CreateHandler();
			var type = rewardHandler.GetType();
			this.rewardHandlersMap[type] = rewardHandler;
			return rewardHandler;
		}

		
	}
}