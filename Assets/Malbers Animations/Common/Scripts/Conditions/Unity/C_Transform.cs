﻿using MalbersAnimations.Scriptables;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace MalbersAnimations.Conditions
{
    public enum TransformCondition { Null, Equal, ChildOf, ParentOf, IsGrandChildOf, IsGrandParentOf,  Name }

    [System.Serializable]
    public class C_Transform : MCondition
    {
        public override string DisplayName => "Unity/Transform";
        public string CheckName { get => checkName; set => checkName = value; }

        [Tooltip("Target to check for the condition ")]
        public TransformReference Target;
        [Tooltip("Conditions types")]
        public TransformCondition Condition;
        [Tooltip("Transform Value to compare with")]
        public TransformReference Value;
        [Tooltip("Name to compare"), SerializeField]
        private string checkName;


        public override bool _Evaluate()
        {
            if (Condition == TransformCondition.Null) return Target.Value == null;

            if (Target.Value != null)
            {
                switch (Condition)
                {
                    case TransformCondition.Name: return Target.Value.name.Contains(CheckName);
                    case TransformCondition.ChildOf: return Target.Value.IsChildOf(Value.Value);
                    case TransformCondition.Equal: return Target.Value == Value.Value;
                    case TransformCondition.ParentOf: return Value.Value.IsChildOf(Target.Value);
                    case TransformCondition.IsGrandChildOf: return Target.Value.SameHierarchy(Value.Value);
                    case TransformCondition.IsGrandParentOf: return Value.Value.SameHierarchy(Target.Value);
                    default: return false;
                }
            }

            return false;
        }

        public override void SetTarget(Object target)
        {
            if (target == null)
            {
                Target.Value = null; //Check Null First
            }
            else if (target is Component)
            {
                Target.Value = (target as Component).transform;
            }
            else if (target is GameObject)
            {
                Target.Value = (target as GameObject).transform;
            }
        }

        public void SetValue(Object target)
        {
            if (target == null)
            {
                Value.Value = null; //Check Null First
            }
            else if (target is Component)
            {
                Value.Value = (target as Component).transform;
            }
            else if (target is GameObject)
            {
                Value.Value = (target as GameObject).transform;
            }
        }

        private void Reset() => Name = "New Transform Condition";
    }


#if UNITY_EDITOR
    [CustomEditor(typeof(C_Transform))]
    public class C_TransformEditor : MConditionEditor
    {
        SerializedProperty checkName;

        protected override void OnEnable()
        {
            base.OnEnable();
            checkName = so.FindProperty("checkName");
        }

        public override void CustomInspector()
        {
            var c = (TransformCondition)Condition.intValue;

            if (c != TransformCondition.Name && 
                c != TransformCondition.Null)  
                EditorGUILayout.PropertyField(Value);
             
            if (c == TransformCondition.Name)
                EditorGUILayout.PropertyField(checkName);
        }
    }
#endif

}
