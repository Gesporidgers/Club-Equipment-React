const Modal = ({ show, onCloseButtonClick }) => {
    if (!show) {
        return null;
    }

    return (
        <div className="modal-wrapper">
            <div className="modal">
                <div className="body">
                    <label>Название прибора</label>
                    <input id="nm" type="text" placeholder="Введите название" />
                    <div/>
                    <label>Количество оборудования</label>
                    <input type="number" id="qty" min="1" max="100" step="1"/>
                </div>
                <div className="footer">
                    <button onClick={onCloseButtonClick}>Close Modal</button>
                </div>
            </div>
        </div>
    );
};

export default Modal;
