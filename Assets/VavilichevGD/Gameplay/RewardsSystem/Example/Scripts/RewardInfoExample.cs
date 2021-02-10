using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace VavilichevGD.Gameplay.Rewards.Example {
	[CreateAssetMenu(fileName = "RewardInfoExample", menuName = "Gameplay/Rewards/New RewardInfoExample")]
	public sealed class RewardInfoExample : RewardInfo {

		[Space]
		[SerializeField] private int m_testValueMin = 10;
		[SerializeField] private int m_testValueMax = 100;

		public int testValueMin => this.m_testValueMin;
		public int testValueMax => this.m_testValueMax;
		
		public override RewardContent GenerateContent() {
			var rTestValue = Random.Range(this.testValueMin, testValueMax + 1);
			return new RewardContentExample(rTestValue);
		}

		public override IRewardHandler CreateHandler() {
			return new RewardHandlerExample();
		}

		public override Type GetRewardHandlerType() {
			return typeof(RewardHandlerExample);
		}
	}
}