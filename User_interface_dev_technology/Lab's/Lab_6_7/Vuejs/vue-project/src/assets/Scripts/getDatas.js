import axios from 'axios'

const getDatas = async(filename) => {
    const path = "http://localhost:5173/" + filename;
    const points = await axios.get(path);
    console.log(points)
    return points;
}

export default getDatas;