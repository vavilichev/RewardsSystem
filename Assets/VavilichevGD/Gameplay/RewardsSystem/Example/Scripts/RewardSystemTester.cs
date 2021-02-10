using UnityEngine;

namespace VavilichevGD.Gameplay.Rewards.Example {
	public sealed class RewardSystemTester : MonoBehaviour {

		public RewardInfo testRewardInfo;
		
		
		private RewardsSystem rewardSystem;
		private Reward reward;

		
		private void Awake() {
			this.rewardSystem = new RewardsSystem();
			this.GenerateReward();
		}

		private void Update() {
			if (Input.GetMouseButtonDown(0))
				this.TestApplyReward();
		}

		
		private void GenerateReward() {
			
			if (this.reward == null)
				this.reward = new Reward(this.testRewardInfo);
			else
				this.reward.RefreshContent();
			
			var content = reward.GetConent<RewardContentExample>();
			Debug.Log($"Next reward generated, value: {content.testValue}");
		}

		private void TestApplyReward() {
			this.rewardSystem.ApplyReward(this, this.reward);
			this.GenerateReward();
		}
	}
}