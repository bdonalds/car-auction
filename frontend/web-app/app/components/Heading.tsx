import React from 'react'

type Props = {
    title: string,
    subtitle: string,
    center?:boolean,
}
const Heading = ({title, subtitle, center}:Props) => {
  return (
    <>
        <div className={center ? 'text-center' : 'text-center'}>
            {title}
        </div>
        <div className="font-light text-neutral-500 mt-2">
            {subtitle}
        </div>
    </>
  )
}

export default Heading