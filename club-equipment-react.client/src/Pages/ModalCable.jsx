const dmx = ['f-f', 'm-m', 'f-m', '3pin-5pin'];
const sound = ['xlrM-xlrF', 'xlrF-xlrF', 'xlrM-xlrM', 'jack-jack', 'jack-xlr'];
const video = ['hdmi', 'sdi'];
const pwr = ['m-m', 'in-m'];

const ModalCable = ({ show, onAddButtonClick, onCloseButtonClick, type }) => {
    if (!show) {
        return null;
    }
    var mode =[];
    switch (type) {
        case 'dmx':
            mode = dmx;
            break;
        case 'sound':
            mode = sound;
            break;
        case 'video':
            mode = video;
            break;
        case 'pwr':
            mode = pwr;
            break
    }


    return (
        <div className="modal-wrapper">
            <div className="modal">
                <div className="body">
                    <label>Тип:</label>
                    <select id="type">
                        {mode.map(opt => <option value={opt}>{opt}</option>)}
                    </select>
                    <div />
                    <label>Длина:</label>
                    <input type="number" id="length" min="0.1" max="100"/>
                    <div />

                    <label>Количество:</label>
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

export default ModalCable;
