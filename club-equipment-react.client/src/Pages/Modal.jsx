const Modal = ({ show, onAddButtonClick,onCloseButtonClick }) => {
    if (!show) {
        return null;
    }

    return (
        <div className="modal-wrapper">
            <div className="modal">
                <div className="body">
                    <label>Название прибора:</label>
                    <input id="nm" type="text" placeholder="Введите название" />
                    <div/>
                    <label>Количество оборудования:</label>
                    <input type="number" id="qty" min="1" max="100" step="1"/>
                </div>
                <div className="footer">
                    <button onClick={onAddButtonClick}>Добавить</button>
                    <button className = "close"onClick={onCloseButtonClick}>Закрыть</button>
                </div>
            </div>
        </div>
    );
};

export default Modal;
