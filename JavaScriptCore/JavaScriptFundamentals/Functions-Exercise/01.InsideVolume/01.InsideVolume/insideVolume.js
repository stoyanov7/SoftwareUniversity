function insideVolume(arr) {
    for (let i = 0; i < arr.length; i+= 3) {
        let x = arr[i];
        let y = arr[i + 1];
        let z = arr[i + 2];

        console.log(isVolume(x, y, z) ? 'inside' : 'outside');
    }

    function inVolume(x, y, z) {
        let volumes1 = { x1: 10, y1: 20, z1: 15 };
        let volumes2 = { x2: 50, y2: 80, z2: 50 };

        if (x >= volumes1.x1 && x <= volumes2.x2) {
            if (y >= volumes1.y1 && y <= volumes2.y2) {
                if (z >= volumes1.z1 && z <= volumes2.z2) {
                    return true;
                }
            }
        }

        return false;
    }
}