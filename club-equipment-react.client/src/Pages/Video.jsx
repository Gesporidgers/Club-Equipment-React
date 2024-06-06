import { useEffect, useState } from 'react';
import axios from 'axios'
import Modal from './Modal';
function Video() {
    var [items, setItems] = useState([]);
    var [showModal, setShowModal] = useState(false);

    const toggleModal = () => { setShowModal(!showModal); };

    useEffect(() => {
        axios.get('api/videods').then((resp) => {
            const allPersons = resp.data;
            setItems(allPersons);
        });
    }, [setItems]);


    const content =
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Наименование</th>
                    <th>Количество</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {items.map(item =>
                    <tr key={item.id}>
                        <td>{item.id}</td>
                        <td>{item.name}</td>
                        <td>{item.quantity}</td>
                        <td><button onClick={() => { delIt(item.id); setItems(items.filter(a => a.id != item.id)); }} >Delete</button></td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <>
            <Modal show={showModal} onCloseButtonClick={toggleModal} onAddButtonClick={() => { toggleModal(); addNew(); }} />
            <h1>ФОТО-ВИДЕО ОБОРУДОВАНИЕ</h1>
            {content}

            <footer>
                <button onClick={toggleModal}>+</button>
            </footer>
        </>

    );

    function delIt(id) {
        axios.delete('api/videods/' + id);

    }

    function addNew() {
        axios.post('api/videods', {
            id: 0,
            name: document.getElementById("nm").value,
            quantity: document.getElementById("qty").value,
        }).then(resp => {
            const dt = resp.data;
            setItems([...items, dt]);
        });

    }
}

export default Video;

