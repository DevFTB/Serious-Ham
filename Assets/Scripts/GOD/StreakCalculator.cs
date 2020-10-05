using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StreakTier
{
    public string Name;
    public int StreakRequirement;
    public AudioClip Sound;
    private class SortByPointsRequired : IComparer<StreakTier>
    {
        public int Compare(StreakTier sl1, StreakTier sl2)
        {
            if (sl1.StreakRequirement > sl2.StreakRequirement)
                return 1;

            if (sl1.StreakRequirement < sl2.StreakRequirement)
                return -1;

            else
                return 0;
        }
    }

    public static IComparer<StreakTier> GetPointsRequiredSort()
    {
        return new SortByPointsRequired();
    }
}

public class StreakCalculator : MonoBehaviour, ISerializationCallbackReceiver
{
    public float TimeTillLoss;
    public List<StreakTier> UnsortedStreakTiers;
    private List<StreakTier> StreakTiers;

    public StreakTier CurrentStreakTier { get => StreakTiers[CurrentStreakTierNumber - 1]; }

    private Timer LossTimer;
    public AudioSource AudioSource;
    public float Streak { get; private set; }


    private int CurrentStreakTierNumber;

    // Start is called before the first frame update
    void Start()
    {
        Streak = 0;
        CurrentStreakTierNumber = 0;

        LossTimer = new Timer(TimeTillLoss);
        LossTimer.Start();

    }

    // Update is called once per frame
    void Update()
    {
        LossTimer.Update();

        VerifyCurrentStreakLevel();
    }

    private void VerifyCurrentStreakLevel()
    {
        if (LossTimer.IsComplete)
        {
            Streak = 0;
            CurrentStreakTierNumber = 0;
            LossTimer.Reset();
        }

        if (Streak >= GetRequiredStreakForNextTier(CurrentStreakTierNumber))
        {
            AudioSource.PlayOneShot(GetStreakTierSound(++CurrentStreakTierNumber));
        }
        else
        {
            if (Streak < GetMinimumStreakForTier(CurrentStreakTierNumber))
            {
                CurrentStreakTierNumber--;
            }
        }

    }

    private int GetRequiredStreakForNextTier(int tier)
    {
        if(tier < StreakTiers.Count)
        {
            return StreakTiers[tier].StreakRequirement;
        }
        else
        {
            return Int32.MaxValue;
        }
    }

    private AudioClip GetStreakTierSound(int tier)
    {
        if (tier > 0) return StreakTiers[tier - 1].Sound;
        else return null;
    }
    private int GetMinimumStreakForTier(int tier)
    {
        if (tier > 0) return StreakTiers[tier - 1].StreakRequirement;
        else return 0;
    }

    public void IncrementStreak()
    {
        Streak++;
        LossTimer.Reset();
    }

    public void OnBeforeSerialize()
    {
        //StreakTiers.Clear();
    }

    public void OnAfterDeserialize()
    {
        StreakTiers = new List<StreakTier>();
        foreach (StreakTier tier in UnsortedStreakTiers)
        {
            StreakTiers.Add(tier);
        }

        StreakTiers.Sort(StreakTier.GetPointsRequiredSort());
    }

    public bool HasStreak()
    {
        return CurrentStreakTierNumber > 0;
    }
}
