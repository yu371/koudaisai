/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Oculus.Interaction.HandGrab;
using UnityEngine;
using UnityEngine.Events;

namespace Oculus.Interaction.Demo
{
    public class BulletFire : MonoBehaviour, IHandGrabUseDelegate
    {
        public enum NozzleMode
        {
            SingleShot,
            RapidFire
        }

        [Header("Input")]
        [SerializeField]
        private Transform _nozzle;
        [SerializeField]
        private AnimationCurve _triggerRotationCurve;
        [SerializeField]
        private SnapAxis _axis = SnapAxis.X;
        [SerializeField]
        [Range(0f, 1f)]
        private float _releaseThresold = 0.3f;
        [SerializeField]
        [Range(0f, 1f)]
        private float _fireThresold = 0.9f;
        [SerializeField]
        private float _triggerSpeed = 3f;
        [SerializeField]
        private AnimationCurve _strengthCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        [Header("Output")]
        [SerializeField]
        private GameObject _bulletPrefab;  // 弾丸のPrefab
        [SerializeField]
        private float _bulletSpeed = 20f;  // 弾丸の速度
        [SerializeField]
        private UnityEvent WhenFire;

        private void FireBullet()
        {
            WhenFire.Invoke();
            
            if (_bulletPrefab != null && _nozzle != null)
            {
                GameObject bullet = Instantiate(_bulletPrefab, _nozzle.position, _nozzle.rotation);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                if (bulletRigidbody != null)
                {
                    bulletRigidbody.velocity = _nozzle.forward * _bulletSpeed;
                }
            }
        }

        private void UpdateTriggerRotation(float progress)
        {
            float value = _triggerRotationCurve.Evaluate(progress);
            // トリガー回転に関連する追加処理が必要ならここに記述
        }

        private NozzleMode GetNozzleMode()
        {
            int rotations = ((int)_nozzle.localEulerAngles.z + 45) / 90;
            return rotations % 2 == 0 ? NozzleMode.SingleShot : NozzleMode.RapidFire;
        }

        public void BeginUse()
        {
            FireBullet();
        }

        public void EndUse()
        {
            // 弾丸発射終了時の処理が必要ならここに記述
        }

        public float ComputeUseStrength(float strength)
        {
            float progress = _strengthCurve.Evaluate(strength);
            UpdateTriggerRotation(progress);
            return progress;
        }
    }
}
