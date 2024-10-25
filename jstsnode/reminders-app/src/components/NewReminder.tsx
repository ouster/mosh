import React from 'react'

interface NewReminderProps {
  onAddReminder: (title: string) => void
}

function NewReminder ({ onAddReminder }: NewReminderProps): JSX.Element {
  const [title, setTitle] = React.useState('')

  const submitForm = (e: React.FormEvent) => {
    e.preventDefault()
    if (!title) return
  }
  return (
    <form onSubmit={submitForm}>
      <label htmlFor='title'></label>
      <input
        value={title}
        onChange={e => setTitle(e.target.value)}
        id='title'
        type='text'
        className='form-control'
      />
      <button type='submit' className='btn btn-primary my-3 rounded-pill'>
        Add Reminder
      </button>
    </form>
  )
}

export default NewReminder
