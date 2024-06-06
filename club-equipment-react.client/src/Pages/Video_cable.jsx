import { useEffect, useState } from 'react';
import axios from 'axios'
import ModalCable from './ModalCable';

function Video_cable() {
    var [items, setItems] = useState([]);
    var [showModal, setShowModal] = useState(false);

    const toggleModal = () => { setShowModal(!showModal); };

    useEffect(() => {
        axios.get('api/videocbl').then((resp) => {
            const allPersons = resp.data;
            setItems(allPersons);
        });
    }, [setItems]);


    const content =
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Тип</th>
                    <th>Длина</th>
                    <th>Количество</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {items.map(item =>
                    <tr key={item.id}>
                        <td>{item.id}</td>
                        <td>{item.type}</td>
                        <td>{item.length} метров</td>
                        <td>{item.quantity}</td>
                        <td><button onClick={() => { delIt(item.id); setItems(items.filter(a => a.id != item.id)); }} >Delete</button></td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <>
            <ModalCable show={showModal} onCloseButtonClick={toggleModal} type='video' onAddButtonClick={() => { toggleModal(); addNew(); }} />
            <h1>Видео кабло</h1>
            {content}

            <footer>
                <button onClick={toggleModal}>+</button>
            </footer>
        </>

    );

    function delIt(id) {
        axios.delete('api/videocbl/' + id);

    }

    function addNew() {
        axios.post('api/videocbl', {
            id: 0,
            type: document.getElementById("type").value,
            length: document.getElementById("length").value,
            quantity: document.getElementById("qty").value,
        }).then(resp => {
            const dt = resp.data;
            setItems([...items, dt]);
        });

    }
}

export default Video_cable;

