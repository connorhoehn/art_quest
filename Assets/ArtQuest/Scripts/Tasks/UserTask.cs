using UnityEngine;

public class UserTask : MonoBehaviour
{

    [SerializeField] protected float TimeForTask;
    [SerializeField] protected bool IsCompleted;


    public virtual void OnEnable()
    {
    }

    public virtual void StartTask()
    {
        // if (LessonManager.Instance)
        LessonManager.Instance.UserTask = this;
    }

    public virtual void EndTask()
    {

    }

    public virtual void ResetTask()
    {

    }
    public virtual void DidCompletedTask(bool value)
    {

    }


}
