import * as React from 'react';

interface InputProps {
    name:string;
    id:string;
    value?: string;
    onchange: (e:any) => void;
}

interface ComboboxProps {
    name:string;
    id:string;
    options: Array<string>;
    onchange: (e:any) => void;
}

export const Input = ({ value = '', name, id, onchange }: InputProps) => {
    return (
        <div className="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <input className="mdl-textfield__input" type="text" id={id} onChange={onchange} />
            <label className="mdl-textfield__label" htmlFor={id} >{name}</label>
        </div>
    )
}

export const Select = ({ options = [], name, id, onchange}: ComboboxProps) => {
    return (
        <div className="mdl-selectfield mdl-js-selectfield">
            <label className="mdl-selectfield__label" htmlFor="myselect">{name}</label>
            <select id={id} name={name} className="mdl-selectfield__select" onChange={onchange}>
                <option value="">Choisir...</option>
                {
                    options.map(option => {
                        return <option key={option} value={option}>{option}</option>
                    })
                }               
            </select>
        </div>
    )
}
