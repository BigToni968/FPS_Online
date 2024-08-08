using UnityEngine;

namespace Patterns
{
    public interface IView
    {
        public void Show();
        public void Hide();
    }

    public interface IViewPresentar : IView
    {
        public IPresenatar Presenatar { get; }

        public void OnInit();
        public void SetPresentar(IPresenatar presenatar);
    }

    public abstract class ViewController : MonoBehaviour, IView
    {
        public virtual void OnInit() { }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }

    public abstract class ViewPresentar : ViewController, IViewPresentar
    {
        public IPresenatar Presenatar { get; private set; }

        public virtual void SetPresentar(IPresenatar presenatar)
        {
            Presenatar = presenatar;
        }
    }
}