import React, { Component } from 'react'
import './TextInput.css'

interface InputProps {
  inputContainerClasses?: string,
  inputClasses?: string,
  type?: 'text' | 'date' | 'email',
  placeholder?: string
}

export default class TextInput extends Component<InputProps> {
  static displayName = TextInput.name

  render () {
    return (
      <div className={`def-input-container ${this.props.inputContainerClasses}`}>
        <input
          className={`def-input ${this.props.inputClasses}`} 
          type={this.props.type}
          placeholder={this.props.placeholder} />
      </div>
    )
  }
}
