using System;
using UnityEngine;

namespace VavilichevGD.Gameplay.Rewards {
	public abstract class RewardInfo : ScriptableObject {

		[SerializeField] private string m_id;
		[SerializeField] private string m_titleCode;
		[SerializeField] private string m_descriptionCode;
		[SerializeField] private Sprite m_spriteIcon;

		public string id => this.m_id;
		public string titleCode => this.m_titleCode;
		public string descriptionCode => this.m_descriptionCode;
		public Sprite spriteIcon => this.m_spriteIcon;

		public abstract RewardContent GenerateContent();
		public abstract IRewardHandler CreateHandler();
		public abstract Type GetRewardHandlerType();
	}
}