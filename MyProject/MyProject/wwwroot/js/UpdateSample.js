document.getElementById('sampleFilter').addEventListener('change', function () {
    const deviceNameElement = document.getElementById('sampleFilter').getAttribute('data-equipmentId');
    const selectedSampleId = this.value;
    const url = `/UnityEntities/DeviceUnity?equipmentId=${encodeURIComponent(deviceNameElement)}&sampleId=${selectedSampleId}`;
    window.location.href = url;
});