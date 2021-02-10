using UnityEngine;

namespace VavilichevGD.Gameplay.Rewards.Example {
	public sealed class RewardHandlerExample : IRewardHandler{
		public void ApplyReward(object sender, Reward reward) {
			var content = reward.GetConent<RewardContentExample>();
			Debug.Log($"REWARD SYSTEM EXAMPLE: Reward received: {reward.info.id}, value: {content.testValue} from: {sender.GetType().Name}");
		}
	}
}