import axios from 'axios'

const getDatas = async(filename) => {
    const path = "http://127.0.0.1:5173/" + filename;
    const points = await axios.get(path);

    return points;
}

export default getDatas;