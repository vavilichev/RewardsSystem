namespace VavilichevGD.Gameplay.Rewards {
	public class Reward {
		
		public RewardInfo info { get; }
		public RewardContent content { get; private set; }
		
		public Reward(RewardInfo rewardInfo) {
			this.info = rewardInfo;
			this.RefreshContent();
		}

		public void RefreshContent() {
			this.content = this.info.GenerateContent();
		}


		public T GetInfo<T>() where T : RewardInfo {
			return (T) this.info;
		}

		public T GetConent<T>() where T : RewardContent {
			return (T) this.content;
		}
	}
}